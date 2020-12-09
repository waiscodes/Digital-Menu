import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { connect } from "react-redux";
import { Link } from "react-router-dom";
import axios from "axios";
import "../css/Details.css";

const Details = (props) => {
  // Refer to Index about params.
  const { id } = useParams();
  const [menuItem, setMenuItem] = useState();
  const [path, setPath] = useState();
  const [loading, setLoading] = useState(true);

  // replace method removes the escape characters added in the backend before it was transferred to the database.
  const renderDetails = (path, menuItem) => {
    return (
      <>
        <section className='details'>
          <h2 className='screen-reader-text'>Details</h2>
          <img src={path + menuItem.imageName} alt='' />
          <div className='price-title'>
            <h2>{menuItem.name.replace(/\\/g, "")}</h2>
            <h2>${menuItem.price}</h2>
          </div>
          <div className='data-group'>
            <p>
              <strong>Description</strong>
            </p>
            <p>{menuItem.description.replace(/\\/g, "")}</p>
          </div>
          <p>
            <strong>Wait Time: </strong>
            {menuItem.waitTimeMins} Minutes
          </p>
          <div className='data-group'>
            <p>
              <strong>Ingredients</strong>
            </p>
            <p>{menuItem.ingredients.replace(/\\/g, "")}</p>
          </div>
          <p>
            {" "}
            <strong> Calories: </strong>
            {menuItem.calories}
          </p>
          <p>
            <strong>Restrictions: </strong>
            {menuItem.halal ? "Halal" : "Haram"}
          </p>
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

  // If the user is logged in, the delete and edit buttons show up for them.
  if (props.activeUser !== undefined) {
    buttons = (
      <>
        <div className='buttons'>
          <Link to={"/m/" + props.activeUser.username}>
            <button onClick={deleteHandler}>Delete</button>
          </Link>
          <Link to={"/edit/" + id}>
            <button>Edit</button>
          </Link>
        </div>
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
