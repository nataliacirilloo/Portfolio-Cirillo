import React from 'react';

const Button = ({ children, onClick, type = 'button', variant = 'primary', disabled = false, style = {}, fullWidth = false }) => {

    const baseStyle = {
        padding: '12px 24px',
        borderRadius: '8px',
        border: 'none',
        fontSize: '1rem',
        fontWeight: '600',
        cursor: disabled ? 'not-allowed' : 'pointer',
        transition: 'background-color 0.2s, transform 0.1s',
        display: 'inline-flex',
        alignItems: 'center',
        justifyContent: 'center',
        width: fullWidth ? '100%' : 'auto',
        opacity: disabled ? 0.6 : 1,
        ...style
    };

    // "Celeste" / Primary System Blue
    const primaryStyle = {
        backgroundColor: '#3b82f6', // bright blue
        color: 'white',
    };

    const secondaryStyle = {
        backgroundColor: '#e5e7eb', // gray-200
        color: '#1f2937', // gray-800
    };

    const finalStyle = {
        ...baseStyle,
        ...(variant === 'primary' ? primaryStyle : secondaryStyle),
    };

    return (
        <button
            type={type}
            onClick={onClick}
            disabled={disabled}
            style={finalStyle}
            onMouseOver={(e) => !disabled && (e.currentTarget.style.opacity = '0.9')}
            onMouseOut={(e) => !disabled && (e.currentTarget.style.opacity = '1')}
            onMouseDown={(e) => !disabled && (e.currentTarget.style.transform = 'scale(0.98)')}
            onMouseUp={(e) => !disabled && (e.currentTarget.style.transform = 'scale(1)')}
        >
            {children}
        </button>
    );
};

export default Button;
