import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import { connect } from "react-redux";
import axios from "axios";

const Details = (props) => {
  const { id } = useParams();
  const [menuItem, setMenuItem] = useState();
  const [path, setPath] = useState();
  const [loading, setLoading] = useState(true);

  const renderDetails = (path, menuItem) => {
    return (
      <>
        <img src={path + menuItem.imageName} alt='' />

        {menuItem.name}
        {menuItem.description}
        {menuItem.price}
        {menuItem.waitTimeMins}
        {menuItem.ingredients}
        {menuItem.calories}
        {menuItem.halal}
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

  useEffect(() => {
    populateDetails();
  }, [loading]);

  let content = loading ? <p>Loading...</p> : renderDetails(path, menuItem);
  let buttons;
  if (props.activeUser !== undefined) {
    buttons = (
      <>
        <button>Delete</button>
        <button>Edit</button>
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
