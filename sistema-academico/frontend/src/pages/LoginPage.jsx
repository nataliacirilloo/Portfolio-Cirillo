import { useState } from 'react';
import { useAuth } from '../context/AuthContext';
import { useNavigate, Link } from 'react-router-dom';
import PageContainer from '../components/ui/PageContainer';
import Card from '../components/ui/Card';
import Input from '../components/ui/Input';
import Button from '../components/ui/Button';

const LoginPage = () => {
    const { login } = useAuth();
    const navigate = useNavigate();
    const [formData, setFormData] = useState({ email: '', password: '' });
    const [error, setError] = useState('');
    const [loading, setLoading] = useState(false);

    const handleSubmit = async (e) => {
        e.preventDefault();
        setLoading(true);
        try {
            await login(formData.email, formData.password);
            navigate('/dashboard');
        } catch (err) {
            console.error(err);
            let msg = 'Error al iniciar sesión.';
            if (err.response?.data) {
                msg = typeof err.response.data === 'string' ? err.response.data : JSON.stringify(err.response.data);
            } else if (err.message) {
                msg = err.message;
            }
            setError(msg);
        } finally {
            setLoading(false);
        }
    };

    return (
        <PageContainer style={{ display: 'flex', justifyContent: 'center', alignItems: 'center' }}>
            <Card style={{ width: '100%', maxWidth: '400px' }}>
                <div style={{ textAlign: 'center', marginBottom: '24px' }}>
                    {/* Student Icon Placeholder */}
                    <div style={{ fontSize: '3rem', color: '#374151', marginBottom: '8px' }}>🎓</div>
                    <h2 style={{ color: '#111827', margin: 0, fontWeight: '700' }}>Iniciar Sesión</h2>
                </div>

                {error && (
                    <div style={{
                        backgroundColor: '#fee2e2',
                        color: '#b91c1c',
                        padding: '12px',
                        borderRadius: '8px',
                        marginBottom: '16px',
                        fontSize: '0.9rem',
                        textAlign: 'center'
                    }}>
                        {error}
                    </div>
                )}

                <form onSubmit={handleSubmit}>
                    <Input
                        label="Email"
                        type="email"
                        value={formData.email}
                        onChange={(e) => setFormData({ ...formData, email: e.target.value })}
                        required
                    />
                    <Input
                        label="Contraseña"
                        type="password"
                        value={formData.password}
                        onChange={(e) => setFormData({ ...formData, password: e.target.value })}
                        required
                    />
                    <Button type="submit" fullWidth disabled={loading}>
                        {loading ? 'Entrando...' : 'Entrar'}
                    </Button>
                </form>

                <div style={{ marginTop: '20px', textAlign: 'center', fontSize: '0.9rem' }}>
                    <span style={{ color: '#6b7280' }}>¿No tienes cuenta? </span>
                    <Link to="/register" style={{ color: '#3b82f6', textDecoration: 'none', fontWeight: '500' }}>
                        Regístrate
                    </Link>
                </div>
            </Card>
        </PageContainer>
    );
};

export default LoginPage;
