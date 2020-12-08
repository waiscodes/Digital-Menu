import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import axios from "axios";
import "../css/Details.css";

const Details = (props) => {
  const { id } = useParams();
  const [menuItem, setMenuItem] = useState();
  const [path, setPath] = useState();
  const [loading, setLoading] = useState(true);

  const renderDetails = (path, menuItem) => {
    return (
      <>
        <section className='details'>
          <h2 className='screen-reader-text'>Details</h2>
          <img src={path + menuItem.imageName} alt='' />
          <div className='price-title'>
            <h2>{menuItem.name}</h2>
            <h2>{menuItem.price}</h2>
          </div>
          <p>{menuItem.description}</p>
          <p>{menuItem.waitTimeMins}</p>
          <p>{menuItem.ingredients}</p>
          <p>{menuItem.calories}</p>
          <p>{menuItem.halal}</p>
        </section>
      </>
    );
  };

  const populateDetails = async () => {
    await axios({
      method: "get",
      url: "Values/ImagePath",
    }).then((response) => {
      setPath(response.data);
    });

    await axios({
      method: "get",
      url: "Values/GetMenuItem",
      params: {
        id: id,
      },
    }).then((response) => {
      setMenuItem(response.data);
      setLoading(false);
    });
  };

  const deleteHandler = async () => {
    await axios({
      method: "delete",
      url: "Values/DeleteMenu",
      params: {
        id: id,
      },
    });
  };

  useEffect(() => {
    populateDetails();
  }, [loading]);

  let content = loading ? <p>Loading...</p> : renderDetails(path, menuItem);
  let buttons;
  if (props.activeUser !== undefined) {
    buttons = (
      <>
        <Link to={"/m/" + props.activeUser.username}>
          <button onClick={deleteHandler}>Delete</button>
        </Link>
        <Link to={"/edit/" + id}>
          <button>Edit</button>
        </Link>
      </>
    );
  }

  return (
    <>
      {content}
      <br />
      {buttons}
    </>
  );
};

export default connect((state) => {
  return {
    activeUser: state,
  };
})(Details);
