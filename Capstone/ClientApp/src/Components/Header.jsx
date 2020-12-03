import React, { useEffect, useState } from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import aActiveUser from "../Actions/aActiveUser";

const Header = (props) => {
  const [activeUser, setActiveUser] = useState("");

  const logoutHandler = () => {
    props.dispatch(aActiveUser(undefined));
    setActiveUser("hello world");
    renderCustomerNav();
    console.log(activeUser);
  };

  const renderAdminNav = (username) => {
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
  const renderCustomerNav = () => {
    return (
      <>
        <li>
          <Link to='/'>Login</Link>
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
    content = renderAdminNav(username);
  } else {
    content = renderCustomerNav();
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
