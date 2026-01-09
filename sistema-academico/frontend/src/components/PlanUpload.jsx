import React, { useState } from 'react';
import api from '../services/api';
import Card from './ui/Card';
import Button from './ui/Button';

const PlanUpload = ({ onUploadSuccess }) => {
    const [file, setFile] = useState(null);
    const [message, setMessage] = useState('');
    const [loading, setLoading] = useState(false);

    const handleFileChange = (e) => {
        setFile(e.target.files[0]);
        setMessage('');
    };

    const handleUpload = async () => {
        if (!file) {
            setMessage('Seleccione un archivo primero.');
            return;
        }

        const formData = new FormData();
        formData.append('file', file);

        setLoading(true);
        try {
            await api.post('/plan/upload', formData, {
                headers: {
                    'Content-Type': 'multipart/form-data',
                },
            });
            setMessage('Plan importado exitosamente.');
            setFile(null); // Reset file input
            if (onUploadSuccess) onUploadSuccess();
        } catch (error) {
            console.error(error);
            const errorMsg = error.response?.data || error.message || 'Error desconocido';
            setMessage('Error al importar el plan: ' + errorMsg);
        } finally {
            setLoading(false);
        }
    };

    return (
        <Card style={{ textAlign: 'center' }}>
            <div style={{ fontSize: '3rem', color: '#10b981', marginBottom: '16px' }}>📊</div>
            <h3 style={{ color: '#1f2937', marginBottom: '24px', fontWeight: '700' }}>Importar Plan de Estudios (Excel)</h3>

            <div style={{ marginBottom: '24px', display: 'flex', justifyContent: 'center' }}>
                <input
                    type="file"
                    accept=".xlsx, .xls"
                    onChange={handleFileChange}
                    style={{
                        padding: '10px',
                        border: '1px solid #d1d5db',
                        borderRadius: '8px',
                        backgroundColor: '#f9fafb',
                        width: '100%',
                        maxWidth: '300px'
                    }}
                />
            </div>

            <div style={{ display: 'flex', justifyContent: 'center' }}>
                <Button onClick={handleUpload} disabled={loading} variant="primary">
                    {loading ? 'Subiendo...' : 'Subir Plan'}
                </Button>
            </div>

            {message && (
                <p style={{
                    marginTop: '20px',
                    color: message.includes('Error') ? '#b91c1c' : '#059669',
                    fontWeight: '500'
                }}>
                    {message}
                </p>
            )}
        </Card>
    );
};

export default PlanUpload;
