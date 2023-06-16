import { AuthenticationResult } from '../../interfaces/auth/authenticationResult';
import { LoginRequest } from '../../interfaces/auth/loginRequest';
import HttpService from '../common/http.service';

export class AuthService {
  private httpService: HttpService;

  constructor() {
    this.httpService = new HttpService(undefined);
  }

  public async login(request: LoginRequest): Promise<AuthenticationResult> {
    return this.httpService.post<AuthenticationResult>('/auth/login', request);
  }

  public async register(request: FormData): Promise<AuthenticationResult> {
    return this.httpService.post<AuthenticationResult>('/auth/register', request);
  }
}

export {};
