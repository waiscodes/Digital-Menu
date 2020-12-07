import React, { useState } from "react";
import { connect } from "react-redux";
import aActiveUser from "../Actions/aActiveUser";
import axios from "axios";
import { Redirect, Link } from "react-router-dom";
import "../css/Login.css";

const Login = (props) => {
  const [response, setResponse] = useState([]);
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [waiting, setWaiting] = useState("");

  const handleFieldChange = (e) => {
    switch (e.target.id) {
      case "email":
        setEmail(e.target.value);
        break;
      case "password":
        setPassword(e.target.value);
        break;
    }
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setWaiting(true);

    axios({
      method: "post",
      url: "Values/Login",
      headers: { "Content-Type": "multipart/form-data" },
      params: {
        email: email,
        password: password,
      },
    })
      .then((res) => {
        setWaiting(false);
        setResponse(res.data);
        props.dispatch(aActiveUser(res.data));
      })
      .catch((err) => {
        setWaiting(false);
        setResponse(err.response.data);
      });
  };

  if (props.activeUser == undefined) {
    return (
      <>
        <section className='login-section'>
          <h3>Login</h3>
          <form onSubmit={handleSubmit}>
            <div className='form-group'>
              <label htmlFor='email' className='.screen-reader-text'>
                Email
              </label>
              <input
                type='email'
                name='email'
                id='email'
                placeholder='Email'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='password' className='.screen-reader-text'>
                password
              </label>
              <input
                type='password'
                name='password'
                id='password'
                placeholder='Password'
                onChange={handleFieldChange}
              />
            </div>
            <div>
              <input type='submit' value='Submit' />
              <p>
                Don't have an account? <Link to='/register'>Register</Link>
              </p>
            </div>
          </form>
        </section>
      </>
    );
  } else if (
    props.activeUser !== undefined &&
    props.activeUser.username != undefined
  ) {
    return <Redirect to={"/m/" + props.activeUser.username} />;
  } else {
    return (
      <>
        <section className='login-section'>
          <h3>Login</h3>
          <form onSubmit={handleSubmit} className='login-form'>
            <div className='form-group'>
              <label htmlFor='email' className='.screen-reader-text'>
                Email
              </label>
              <input
                type='email'
                name='email'
                id='email'
                placeholder='Email'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='password'>password</label>
              <input
                type='password'
                name='password'
                id='password'
                placeholder='Password'
                onChange={handleFieldChange}
              />
            </div>
            <div>
              <input type='submit' value='Submit' />
              <p>
                Don't have an account? <Link to='/register'>Register</Link>
              </p>
            </div>
          </form>
        </section>
      </>
    );
  }
};

export default connect((state) => {
  return {
    activeUser: state,
  };
})(Login);
