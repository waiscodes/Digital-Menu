import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import Details from "./Components/Details";
import Login from "./Components/Login";

ReactDOM.render(
  <React.StrictMode>
    <>
      <Login />
    </>
  </React.StrictMode>,
  document.getElementById("root")
);
