import React, { useEffect, useState } from 'react';
import api from '../services/api';
import Card from './ui/Card';

const MateriaList = ({ onUpdate, refreshTrigger }) => {
    const [materias, setMaterias] = useState([]);

    useEffect(() => {
        fetchMaterias();
    }, [refreshTrigger]);

    const fetchMaterias = async () => {
        try {
            const response = await api.get('/materias');
            const sorted = response.data.sort((a, b) => {
                if (a.anio !== b.anio) return a.anio - b.anio;
                return a.cuatrimestre - b.cuatrimestre;
            });
            setMaterias(sorted);
        } catch (error) {
            console.error("Error fetching materias", error);
        }
    };

    const handleStatusChange = async (id, newStatus) => {
        try {
            await api.put(`/materias/${id}/estado`, { estado: newStatus });
            fetchMaterias();
            if (onUpdate) onUpdate();
        } catch (error) {
            console.error("Status update error:", error);
            alert('Error al actualizar estado');
        }
    };

    const getStatusStyle = (status) => {
        switch (status) {
            case 'APROBADA': return { bg: '#dcfce7', text: '#166534' }; // Green-100 / Green-800
            case 'CURSANDO': return { bg: '#f3e8ff', text: '#6b21a8' }; // Purple-100 / Purple-800
            case 'PENDIENTE': return { bg: '#fff1f2', text: '#9f1239' }; // Rose-100 / Rose-800
            case 'BLOQUEADA': return { bg: '#f3f4f6', text: '#6b7280' }; // Gray-100 / Gray-500
            default: return { bg: 'white', text: 'black' };
        }
    };

    return (
        <Card>
            <div style={{ display: 'flex', alignItems: 'center', marginBottom: '20px' }}>
                <span style={{ fontSize: '1.5rem', marginRight: '10px' }}>📋</span>
                <h3 style={{ color: '#1f2937', margin: 0, fontWeight: '700' }}>Plan de Estudios</h3>
            </div>

            <div style={{ overflowX: 'auto' }}>
                <table style={{ width: '100%', borderCollapse: 'separate', borderSpacing: '0' }}>
                    <thead>
                        <tr style={{ textAlign: 'left' }}>
                            <th style={{ padding: '16px', borderBottom: '2px solid #e5e7eb', color: '#111827', fontWeight: '600' }}>Año</th>
                            <th style={{ padding: '16px', borderBottom: '2px solid #e5e7eb', color: '#111827', fontWeight: '600' }}>Cuat.</th>
                            <th style={{ padding: '16px', borderBottom: '2px solid #e5e7eb', color: '#111827', fontWeight: '600', width: '40%' }}>Materia</th>
                            <th style={{ padding: '16px', borderBottom: '2px solid #e5e7eb', color: '#111827', fontWeight: '600', textAlign: 'center' }}>Créditos</th>
                            <th style={{ padding: '16px', borderBottom: '2px solid #e5e7eb', color: '#111827', fontWeight: '600', textAlign: 'center' }}>Estado</th>
                            <th style={{ padding: '16px', borderBottom: '2px solid #e5e7eb', color: '#111827', fontWeight: '600', textAlign: 'center' }}>Acción</th>
                        </tr>
                    </thead>
                    <tbody>
                        {materias.map((m) => {
                            const isBloqueada = m.estado === 'BLOQUEADA';
                            const style = getStatusStyle(m.estado);

                            // Tooltip logic for blocked
                            const tooltip = m.correlativasFaltantes && m.correlativasFaltantes.length > 0
                                ? `Faltan: ${m.correlativasFaltantes.join(', ')}`
                                : '';

                            return (
                                <tr key={m.id} style={{ transition: 'background-color 0.1s' }} title={tooltip}>
                                    <td style={{ padding: '16px', borderBottom: '1px solid #f3f4f6', color: '#4b5563' }}>{m.anio}</td>
                                    <td style={{ padding: '16px', borderBottom: '1px solid #f3f4f6', color: '#4b5563' }}>{m.cuatrimestre}</td>
                                    <td style={{ padding: '16px', borderBottom: '1px solid #f3f4f6', fontWeight: '600', color: isBloqueada ? '#9ca3af' : '#1f2937' }}>
                                        {m.nombre}
                                        {isBloqueada && <span style={{ fontSize: '0.8em', marginLeft: '8px' }}>🔒</span>}
                                    </td>
                                    <td style={{ padding: '16px', borderBottom: '1px solid #f3f4f6', textAlign: 'center', color: '#4b5563' }}>{m.creditos}</td>
                                    <td style={{ padding: '16px', borderBottom: '1px solid #f3f4f6', textAlign: 'center' }}>
                                        <span style={{
                                            backgroundColor: style.bg,
                                            color: style.text,
                                            padding: '4px 12px',
                                            borderRadius: '9999px',
                                            fontSize: '0.85rem',
                                            fontWeight: '600'
                                        }}>
                                            {m.estado}
                                        </span>
                                    </td>
                                    <td style={{ padding: '16px', borderBottom: '1px solid #f3f4f6', textAlign: 'center' }}>
                                        {!isBloqueada && (
                                            <select
                                                value={m.estado}
                                                onChange={(e) => handleStatusChange(m.id, e.target.value)}
                                                style={{
                                                    padding: '6px 12px',
                                                    borderRadius: '6px',
                                                    border: '1px solid #d1d5db',
                                                    backgroundColor: 'white',
                                                    cursor: 'pointer',
                                                    color: '#374151',
                                                    fontSize: '0.9rem'
                                                }}
                                            >
                                                <option value="PENDIENTE">PENDIENTE</option>
                                                <option value="CURSANDO">CURSANDO</option>
                                                <option value="APROBADA">APROBADA</option>
                                            </select>
                                        )}
                                    </td>
                                </tr>
                            );
                        })}
                    </tbody>
                </table>
            </div>
        </Card>
    );
};

export default MateriaList;
