import React from 'react';
import ReactDOM from 'react-dom'
import {BrowserRouter as Router} from 'react-router-dom';
import Details from './Components/Details';
import Register from './Components/Register';

ReactDOM.render(
  <React.StrictMode>
    <>
    <Register />
    </>
  </React.StrictMode>,
  document.getElementById('root')
);