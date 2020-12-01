import React from "react";
import { Link } from "react-router-dom";

const Header = () => {
  return (
    <>
      <header>
        <nav>
          <ul>
            <li>
              <Link>Home</Link>
            </li>
            <li>
              <Link>Create</Link>
            </li>
            <li>
              <Link>Logout</Link>
            </li>
            <li>
              <Link>Home</Link>
            </li>
            <li>
              <Link>Home</Link>
            </li>
          </ul>
        </nav>
      </header>
    </>
  );
};
