import React, { useState, useEffect } from "react";
import { useParams } from "react-router-dom";
import axios from "axios";

const Details = (props) => {
  const { id } = useParams();
  const [menuItem, setMenuItem] = useState();
  const [path, setPath] = useState();
  const [loading, setLoading] = useState(true);

  const renderDetails = (menuItem) => {
    return (
      <>
        {/* <pre>{JSON.stringify(menuItem, null, 2)}</pre> */}
        {id}
      </>
    );
  };

  const renderPath = (path, imageName) => {
    return <>{path + imageName}</>;
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

  let content = loading ? (
    <p>Loading...</p>
  ) : (
    renderPath(path, menuItem.imageName)
  );

  return <>{content}</>;
};

export default Details;
