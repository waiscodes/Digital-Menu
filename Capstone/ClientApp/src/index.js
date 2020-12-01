import React from 'react';
import ReactDOM from 'react-dom'
import {BrowserRouter as Router} from 'react-router-dom';
import Details from './Components/Details';
import MenuCard from './Components/MenuCard';

ReactDOM.render(
  <React.StrictMode>
    <>
    <MenuCard />
    </>
  </React.StrictMode>,
  document.getElementById('root')
);