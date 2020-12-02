import React from "react";
import ReactDOM from "react-dom";
import { createStore } from "redux";
import { Provider } from "react-redux";
import { BrowserRouter as Router, Route } from "react-router-dom";

// Components
import Header from "./Components/Header";
import Footer from "./Components/Footer";
import Create from "./Components/Create";
import Details from "./Components/Details";
import Menu from "./Components/Menu";
import Register from "./Components/Register";
import Login from "./Components/Login";

//Redux Actions & Reducers
import aActiveUser from "./Actions/aActiveUser";
import rActiveUser from "./Reducers/rActiveUser";

const myStore = createStore(
  rActiveUser,
  window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
);

ReactDOM.render(
  <React.StrictMode>
    <>
      <Provider store={myStore}>
        <Router>
          <Header />
          <Route path='/Register' component={Register} />
          <Route path='/' component={Login} exact />
          <Route path='/m/:username' component={Menu} exact />
          <Route path='/Details/:id' component={Details} />
          <Route path='/Create' component={Create} />
          <Footer />
        </Router>
      </Provider>
    </>
  </React.StrictMode>,
  document.getElementById("root")
);
