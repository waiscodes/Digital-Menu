import React from "react";
import ReactDOM from "react-dom";
import { BrowserRouter as Router, Route } from "react-router-dom";

// Components
import Header from "./Components/Header";
import Footer from "./Components/Footer";
import Create from "./Components/Create";
import Details from "./Components/Details";
import Menu from "./Components/Menu";
import Register from "./Components/Register";
import Login from "./Components/Login";

ReactDOM.render(
  <React.StrictMode>
    <>
      <Router>
        <Header />
        <Route path='/Register' component={Register} />
        <Route path='/' component={Login} exact />
        <Route path='/m/:username' component={Menu} exact />
        <Route path='/Details/:id' component={Details} />
        <Route path='/Create' component={Create} />
        <Footer />
      </Router>
    </>
  </React.StrictMode>,
  document.getElementById("root")
);
