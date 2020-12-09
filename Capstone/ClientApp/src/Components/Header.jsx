import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import aActiveUser from "../Actions/aActiveUser";
import "../css/Header.css";

const Header = (props) => {
  let content = "";
  const logoutHandler = () => {
    props.dispatch(aActiveUser(undefined));
  };
  // Different headers based on whether the user is logged in.
  // Nav bar to home and log in isn't showed to customer. They just need to see the menu and that's it.
  const renderAdminNav = (username) => {
    return (
      <>
        <h1>Digital Menu</h1>
        <nav>
          <ul>
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
          </ul>
        </nav>
      </>
    );
  };
  const renderCustomerNav = () => {
    return (
      <>
        <h1>Digital Menu</h1>
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
      <header>{content}</header>
    </>
  );
};
export default connect((state) => {
  return {
    activeUser: state,
  };
})(Header);
