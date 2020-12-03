import React, { useState } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import aActiveUser from "../Actions/aActiveUser";

const Header = (props) => {
  const logoutHandler = () => {
    props.dispatch(aActiveUser(undefined));
    renderCustomerHeader();
  };

  const renderAdminHeader = (username) => {
    return (
      <>
        <li>
          <Link to={"/m/" + username}>Home</Link>
        </li>
        <li>
          <Link to='/Create'>Create</Link>
        </li>
        <li>
          <Link to='/' onClick={logoutHandler}>
            Logout
          </Link>
        </li>
        <li>
          <Link to='/Register'>Register</Link>
        </li>
      </>
    );
  };
  const renderCustomerHeader = () => {
    return (
      <>
        <li>
          <Link to='/Login'>Login</Link>
        </li>
        <li>
          <Link to='/Register'>Register</Link>
        </li>
      </>
    );
  };

  let content = "";
  if (props.activeUser !== undefined) {
    let username = props.activeUser.username;
    content = renderAdminHeader(username);
  } else {
    content = renderCustomerHeader();
  }
  return (
    <>
      <header>
        <nav>
          <ul>{content}</ul>
        </nav>
      </header>
    </>
  );
};
export default connect((state) => {
  return {
    activeUser: state,
  };
})(Header);
