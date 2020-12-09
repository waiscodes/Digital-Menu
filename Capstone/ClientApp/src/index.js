import React from "react";
import ReactDOM from "react-dom";
import { createStore } from "redux";
import { Provider } from "react-redux";
import { BrowserRouter as Router, Route } from "react-router-dom";

import "./css/custom.css";

// Components
import Header from "./Components/Header";
import Footer from "./Components/Footer";
import Create from "./Components/Create";
import Details from "./Components/Details";
import Menu from "./Components/Menu";
import Register from "./Components/Register";
import Login from "./Components/Login";
import Edit from "./Components/Edit";

//Redux Actions & Reducers
import rActiveUser from "./Reducers/rActiveUser";

const myStore = createStore(
  rActiveUser,
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

// /: is a use param. It is a dynamic path that can also be retrieved by the component to show specific type of data
ReactDOM.render(
  <React.StrictMode>
    <>
      <Provider store={myStore}>
        <Router>
          <Header />
          <main>
            <Route path='/Register' component={Register} />
            <Route path='/' component={Login} exact />
            <Route path='/m/:username' component={Menu} exact />
            <Route path='/Details/:id' component={Details} />
            <Route path='/Create' component={Create} />
            <Route path='/Edit/:id' component={Edit} />
          </main>
          <Footer />
        </Router>
      </Provider>
    </>
  </React.StrictMode>,
  document.getElementById("root")
);
