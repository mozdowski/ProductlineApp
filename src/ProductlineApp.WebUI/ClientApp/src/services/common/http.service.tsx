import axios, {
  AxiosInstance,
  AxiosRequestConfig,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from 'axios';

class HttpService {
  private http: AxiosInstance;
  private authToken: string | undefined;

  constructor(authToken: string | undefined) {
    this.http = axios.create({
      baseURL: process.env.REACT_APP_API_SERVER_URL,
      headers: {
        'Content-Type': 'application/json',
      },
    });

    this.authToken = authToken;

    this.http.interceptors.request.use((config: InternalAxiosRequestConfig) => {
      if (this.authToken) {
        config.headers['Authorization'] = `Bearer ${this.authToken}`;
      }
      return config;
    });

    this.http.interceptors.response.use(this.handleResponse, this.handleError);
  }

  private handleResponse<T>(response: AxiosResponse<T>) {
    if (response.status >= 200 && response.status <= 299) {
      return response.data;
    } else {
      throw new Error(response.statusText);
    }
  }

  private handleError(error: any) {
    // logika obsługi błędów
    throw new Error(error.response?.data?.message || error.message);
  }

  async get<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    return this.http.get<T>(url, config).then((response) => response as T);
  }

  async post<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<T> {
    if (data instanceof FormData) {
      config = {
        ...config,
        headers: {
          ...config?.headers,
          'Content-Type': 'multipart/form-data',
        },
      };
    }
    return this.http.post<T>(url, data, config).then((response) => response as T);
  }

  async put<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<T> {
    return this.http.put<T>(url, data, config).then((response: { data: T }) => {
      return response.data;
    });
  }

  async delete<T>(url: string, config?: AxiosRequestConfig): Promise<T> {
    return this.http.delete<T>(url, config).then((response: { data: T }) => {
      return response.data;
    });
  }
}

export default HttpService;
