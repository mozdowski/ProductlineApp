import { useAuthContext } from "./useAuthContext";

export const useAuth = () => {
    const authContext = useAuthContext();

    if (!authContext) {
        throw new Error('useAuth must be used within an AuthProvider');
    }

    const { user, login, logout } = authContext;

    return { user, login, logout };
};

export { };