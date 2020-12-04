import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import aActiveUser from "../Actions/aActiveUser";

const Header = (props) => {
  let content = "";
  const logoutHandler = () => {
    props.dispatch(aActiveUser(undefined));
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

  if (
    props.activeUser !== undefined &&
    props.activeUser.username !== undefined
  ) {
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
