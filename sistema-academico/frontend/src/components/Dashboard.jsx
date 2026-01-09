import React, { useEffect, useState } from 'react';
import { PieChart, Pie, Cell, Tooltip, Legend, ResponsiveContainer } from 'recharts';
import api from '../services/api';
import Card from './ui/Card';

const Dashboard = ({ refreshTrigger }) => {
    const [stats, setStats] = useState({ totalMaterias: 0, materiasAprobadas: 0, porcentajeAvance: 0 });

    useEffect(() => {
        const fetchStats = async () => {
            try {
                const response = await api.get('/materias/dashboard');
                setStats(response.data);
            } catch (error) {
                console.error("Error loading dashboard", error);
            }
        };
        fetchStats();
    }, [refreshTrigger]);

    const data = [
        { name: 'Aprobadas', value: stats.materiasAprobadas },
        { name: 'Cursando', value: stats.materiasCursadas || 0 },
        { name: 'Pendientes', value: stats.materiasPendientes || 0 },
        { name: 'Bloqueadas', value: stats.materiasBloqueadas || 0 },
    ];

    // Colors: Keep soft palette
    const COLORS = ['#10b981', '#a78bfa', '#f472b6', '#9ca3af'];

    return (
        <Card>
            <div style={{ display: 'flex', flexWrap: 'wrap', justifyContent: 'space-around', alignItems: 'center' }}>
                <div style={{ flex: '1 1 300px', padding: '20px' }}>
                    <h2 style={{ color: '#1f2937', margin: 0, fontWeight: '700' }}>Progreso Académico</h2>
                    {stats.carrera && <h4 style={{ margin: '8px 0', color: '#6b7280', fontWeight: '500' }}>{stats.carrera}</h4>}
                    {stats.alumno && (
                        <div style={{ display: 'flex', alignItems: 'center', marginBottom: '20px', color: '#6b7280' }}>
                            <span style={{ marginRight: '8px' }}>👤</span>
                            <h5 style={{ margin: 0, fontWeight: '500' }}>{stats.alumno}</h5>
                        </div>
                    )}

                    <div style={{ marginTop: '30px' }}>
                        <h1 style={{ fontSize: '4rem', margin: '0', color: '#111827', fontWeight: '800', lineHeight: 1 }}>
                            {stats.porcentajeAvance}%
                        </h1>
                        <p style={{ color: '#9ca3af', fontSize: '1.1rem', marginTop: '8px' }}>
                            Completado
                        </p>
                        <div style={{ marginTop: '16px', fontSize: '1.2rem', color: '#4b5563' }}>
                            <strong>{stats.materiasAprobadas}</strong> / {stats.totalMaterias} materias aprobadas
                        </div>
                    </div>
                </div>

                <div style={{ flex: '1 1 300px', height: '300px', minWidth: '300px' }}>
                    <ResponsiveContainer width="100%" height="100%">
                        <PieChart>
                            <Pie
                                data={data}
                                innerRadius={70}
                                outerRadius={90}
                                paddingAngle={5}
                                dataKey="value"
                            >
                                {data.map((entry, index) => (
                                    <Cell key={`cell-${index}`} fill={COLORS[index % COLORS.length]} stroke="none" />
                                ))}
                            </Pie>
                            <Tooltip
                                contentStyle={{ backgroundColor: '#fff', borderRadius: '8px', border: 'none', boxShadow: '0 4px 6px rgba(0,0,0,0.1)' }}
                            />
                            <Legend verticalAlign="bottom" height={36} />
                        </PieChart>
                    </ResponsiveContainer>
                </div>
            </div>
        </Card>
    );
};

export default Dashboard;
