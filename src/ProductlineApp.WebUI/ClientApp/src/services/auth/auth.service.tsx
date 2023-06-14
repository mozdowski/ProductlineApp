import { AuthenticationResult } from "../../interfaces/auth/authenticationResult";
import { LoginRequest } from "../../interfaces/auth/loginRequest";
import { RegisterRequest } from "../../interfaces/auth/registerRequest";
import HttpService from "../common/HttpService";

export class AuthService {
    private httpService: HttpService;

    constructor() {
        this.httpService = new HttpService();
    }

    public login(request: LoginRequest): Promise<AuthenticationResult> {
        return this.httpService.post<AuthenticationResult>('/auth/login', request);
    }

    public register(request: RegisterRequest): Promise<AuthenticationResult> {
        return this.httpService.post<AuthenticationResult>('/auth/register', request);
    }
};

export { };