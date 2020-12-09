import React, { useState } from "react";
import { connect } from "react-redux";
import aActiveUser from "../Actions/aActiveUser";
import axios from "axios";
import { Redirect, Link } from "react-router-dom";
import "../css/Register.css";

// Once user info is captured, it is sent to axios and if if doesn't throw an exception, it returns a username which is set to the global state.

const Register = (props) => {
  const [response, setResponse] = useState([]);
  const [resName, setResName] = useState();
  const [resUsername, setResUsername] = useState();
  const [resLocation, setResLocation] = useState();
  const [email, setEmail] = useState();
  const [password, setPassword] = useState();
  const [waiting, setWaiting] = useState();

  // if the global state username is not null, username is set to the user variable
  const user = props.activeUser
    ? props.activeUser.username
      ? props.activeUser.username
      : undefined
    : undefined;

  const handleFieldChange = (e) => {
    switch (e.target.id) {
      case "resName":
        setResName(e.target.value);
        break;
      case "resUsername":
        setResUsername(e.target.value);
        break;
      case "resLocation":
        setResLocation(e.target.value);
        break;
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
      url: "Values/Register",
      headers: { "Content-Type": "multipart/form-data" },
      params: {
        resName: resName,
        resUsername: resUsername,
        email: email,
        password: password,
        resLocation: resLocation,
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

  // if the user is set (refer to comments above) it redirects user to homepage
  if (user == undefined) {
    return (
      <>
        <section className='register-section'>
          <h3>Register</h3>
          <p>{response}</p>
          <form onSubmit={handleSubmit}>
            <div className='form-group'>
              <label htmlFor='resName'>Restaurant Name</label>
              <input
                type='text'
                name='resName'
                id='resName'
                maxLength='75'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='resUsername'>Restaurant Username</label>
              <input
                type='text'
                name='resUsername'
                id='resUsername'
                maxLength='30'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='resLocation'>Restaurant Location</label>
              <input
                type='text'
                name='resLocation'
                id='resLocation'
                maxLength='75'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='email'>Email</label>
              <input
                type='email'
                name='email'
                id='email'
                maxLength='64'
                onChange={handleFieldChange}
              />
            </div>
            <div className='form-group'>
              <label htmlFor='password'>password</label>
              <input
                type='password'
                name='password'
                id='password'
                maxLength='50'
                onChange={handleFieldChange}
              />
            </div>
            <div>
              <input type='submit' value='Submit' />
              <p>
                Already have an account? <Link to='/'>Login</Link>
              </p>
            </div>
          </form>
        </section>
      </>
    );
  } else {
    return <Redirect to={"/m/" + props.activeUser.username} />;
  }
};

export default connect((state) => {
  return {
    activeUser: state,
  };
})(Register);
