import React, { useState } from 'react';

const PrintMap: React.FC = () => {
  const [cityName, setCityName] = useState('');

  const onPrint = async () => {
    try {
      const response = await fetch(`http://localhost:5295/api/render/city?name=${cityName}`, {
        method: 'GET',
      });
      
      const blob = await response.blob();
      const url = window.URL.createObjectURL(blob);
      const a = document.createElement('a');
      a.href = url;
      a.download = `${cityName}.pdf`;
      a.click();
      window.URL.revokeObjectURL(url);
    } catch (error) {
      console.error('Error downloading PDF:', error);
    }
  };

  return (
    <div>
      <p>Print maps service: </p>
      <input
        type="text"
        value={cityName}
        onChange={(e) => setCityName(e.target.value)}
        placeholder="Enter city name"
      />
      <button onClick={onPrint}>Print</button>
    </div>
  );
};

export default PrintMap;
