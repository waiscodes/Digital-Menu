import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <>
      <header>
        <nav>
          <ul>
            <li>
              <Link to='/'>Home</Link>
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
};
export default Header;
