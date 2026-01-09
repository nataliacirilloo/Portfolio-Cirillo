import React from 'react';

const PageContainer = ({ children, style = {} }) => {
    return (
        <div style={{
            minHeight: '100vh',
            backgroundColor: '#f2f3f5',
            padding: '20px',
            fontFamily: "'Inter', sans-serif", // Clean font
            color: '#1f2937', // Gray-800 text
            ...style
        }}>
            {children}
        </div>
    );
};

export default PageContainer;
