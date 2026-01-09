import { createContext, useContext, useState, useEffect } from 'react';
import api from '../services/api';

const AuthContext = createContext();

export const AuthProvider = ({ children }) => {
    const [user, setUser] = useState(null);
    const [token, setToken] = useState(localStorage.getItem('token'));
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        if (token) {
            // Validate token or just parse it if using JWT decode
            localStorage.setItem('token', token);
            api.defaults.headers.common['Authorization'] = `Bearer ${token}`;
            // Optional: fetch user data from /me endpoint if exists
            setUser({ email: 'Loaded from token' }); // Placeholder until /me is implemented
            setLoading(false);
        } else {
            localStorage.removeItem('token');
            delete api.defaults.headers.common['Authorization'];
            setUser(null);
            setLoading(false);
        }
    }, [token]);

    const login = async (email, password) => {
        const response = await api.post('/auth/login', { email, password });
        setToken(response.data.token);
    };

    const register = async (userData) => {
        const response = await api.post('/auth/register', userData);
        setToken(response.data.token);
    };

    const logout = () => {
        setToken(null);
    };

    return (
        <AuthContext.Provider value={{ user, token, login, register, logout, loading }}>
            {children}
        </AuthContext.Provider>
    );
};

export const useAuth = () => useContext(AuthContext);
