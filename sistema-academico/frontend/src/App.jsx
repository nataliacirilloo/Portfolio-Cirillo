import React from 'react';
import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom';
import { AuthProvider, useAuth } from './context/AuthContext';
import LoginPage from './pages/LoginPage';
import RegisterPage from './pages/RegisterPage';
import ProtectedRoute from './components/layout/ProtectedRoute';
import Dashboard from './components/Dashboard';
import MateriaList from './components/MateriaList';
import PlanUpload from './components/PlanUpload';
import './App.css';

import PageContainer from './components/ui/PageContainer';
import Button from './components/ui/Button';

const DashboardLayout = () => {
  const [refresh, setRefresh] = React.useState(0);
  const { logout } = useAuth(); // Assuming useAuth is available here or need to import

  const triggerRefresh = () => {
    setRefresh(prev => prev + 1);
  };

  return (
    <PageContainer>
      <header style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: '30px' }}>
        <div style={{ display: 'flex', alignItems: 'center' }}>
          <div style={{ fontSize: '2rem', marginRight: '12px' }}>🎓</div>
          <h1 style={{ color: '#111827', margin: 0, fontSize: '1.5rem', fontWeight: '700' }}>
            Sistema Académico
          </h1>
        </div>
        {/* Logout button */}
        <Button variant="secondary" onClick={logout} style={{ fontSize: '0.9rem', padding: '8px 16px' }}>
          Cerrar Sesión
        </Button>
      </header>

      <div style={{ maxWidth: '1200px', margin: '0 auto' }}>
        <Dashboard refreshTrigger={refresh} />
        <PlanUpload onUploadSuccess={triggerRefresh} />
        <MateriaList onUpdate={triggerRefresh} refreshTrigger={refresh} />
      </div>
    </PageContainer>
  );
};

function App() {
  return (
    <AuthProvider>
      <Router>
        <Routes>
          <Route path="/login" element={<LoginPage />} />
          <Route path="/register" element={<RegisterPage />} />

          {/* Protected Routes */}
          <Route element={<ProtectedRoute />}>
            <Route path="/dashboard" element={<DashboardLayout />} />
            <Route path="/" element={<Navigate to="/dashboard" replace />} />
          </Route>
        </Routes>
      </Router>
    </AuthProvider>
  );
}

export default App;
