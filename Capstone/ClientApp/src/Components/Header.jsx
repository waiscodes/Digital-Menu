import React from "react";
import { connect } from "react-redux";
import { Link } from "react-router-dom";

const Header = (props) => {
  let username = "";
  if (props.activeUser !== undefined) {
    username = props.activeUser.username;
    return (
      <>
        <header>
          <nav>
            <ul>
              <li>
                <Link to={"/m/" + username}>Home</Link>
              </li>
              <li>
                <Link to='/Create'>Create</Link>
              </li>
              <li>
                <Link to='/Login'>Logout</Link>
              </li>
              <li>
                <Link to='/Register'>Register</Link>
              </li>
            </ul>
          </nav>
        </header>
      </>
    );
  } else {
    return (
      <>
        <header>
          <nav>
            <ul>
              <li>
                <Link to='/Login'>Login</Link>
              </li>
              <li>
                <Link to='/Register'>Register</Link>
              </li>
            </ul>
          </nav>
        </header>
      </>
    );
  }
};
export default connect((state) => {
  return {
    activeUser: state,
  };
})(Header);
