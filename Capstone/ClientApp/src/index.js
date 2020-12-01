import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router } from "react-router-dom";
import Details from "./Components/Details";
import Create from "./Components/Create";

ReactDOM.render(
  <React.StrictMode>
    <>
      <Create />
    </>
  </React.StrictMode>,
  document.getElementById("root")
);
