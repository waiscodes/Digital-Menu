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
            <li>
              <Link to='/Register'>Register</Link>
            </li>
          </ul>
        </nav>
      </>
    );
  };
  const renderCustomerNav = () => {
    return (
      <>
        <h1>Our Menu</h1>
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
