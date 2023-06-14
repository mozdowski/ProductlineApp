import axios, {
  AxiosInstance,
  AxiosRequestConfig,
  AxiosResponse,
  InternalAxiosRequestConfig,
} from 'axios';

class HttpService {
  private http: AxiosInstance;

  constructor() {
    this.http = axios.create({
      baseURL: 'adres_url', // Zmienic na wartosc z pliku configuracyjnego
      headers: {
        'Content-Type': 'application/json',
      },
    });

    this.http.interceptors.request.use((config: InternalAxiosRequestConfig) => {
      const token = 'TUTAJ_TOKEN_BEARER';
      if (token) {
        config.headers['Authorization'] = `Bearer ${token}`;
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
    return this.http.get<T>(url, config).then((response) => response.data);
  }

  async post<T>(url: string, data?: any, config?: AxiosRequestConfig): Promise<T> {
    return this.http.post<T>(url, data, config).then((response) => response.data);
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
