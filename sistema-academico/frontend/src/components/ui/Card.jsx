import React from 'react';

const Card = ({ children, style = {}, className = '' }) => {
    return (
        <div
            className={`ui-card ${className}`}
            style={{
                backgroundColor: '#ffffff',
                borderRadius: '12px',
                boxShadow: '0 4px 6px rgba(0, 0, 0, 0.05)',
                padding: '24px',
                marginBottom: '20px',
                border: '1px solid #e5e7eb', // subtle border
                ...style
            }}
        >
            {children}
        </div>
    );
};

export default Card;
