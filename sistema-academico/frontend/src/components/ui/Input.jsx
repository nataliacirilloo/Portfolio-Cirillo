import React from 'react';

const Input = ({ label, type = 'text', value, onChange, placeholder, required = false, style = {} }) => {
    return (
        <div style={{ marginBottom: '16px', ...style }}>
            {label && (
                <label style={{
                    display: 'block',
                    marginBottom: '8px',
                    fontSize: '0.9rem',
                    fontWeight: '500',
                    color: '#374151' // Gray-700
                }}>
                    {label}
                </label>
            )}
            <input
                type={type}
                value={value}
                onChange={onChange}
                placeholder={placeholder}
                required={required}
                style={{
                    width: '100%',
                    padding: '12px 16px',
                    borderRadius: '8px',
                    border: '1px solid #d1d5db', // Gray-300
                    backgroundColor: '#f9fafb', // Gray-50
                    fontSize: '1rem',
                    color: '#111827', // Gray-900
                    outline: 'none',
                    transition: 'border-color 0.2s',
                    boxSizing: 'border-box'
                }}
                onFocus={(e) => e.target.style.borderColor = '#3b82f6'} // Blue-500 focus
                onBlur={(e) => e.target.style.borderColor = '#d1d5db'}
            />
        </div>
    );
};

export default Input;
