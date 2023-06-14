import { useAuthContext } from "./useAuthContext";

export const useAuth = () => {
    const authContext = useAuthContext();

    if (!authContext) {
        throw new Error('useAuth must be used within an AuthProvider');
    }

    const { user, register, login, logout, isAuthenticated } = authContext;

    return { user, register, login, logout, isAuthenticated };
};

export { };