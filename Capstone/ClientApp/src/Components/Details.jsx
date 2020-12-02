import React, { useState, useEffect } from "react";
import axios from "axios";

const Details = (props) => {
  const [menuItem, setMenuItem] = useState();
  const [path, setPath] = useState();
  const [loading, setLoading] = useState(true);

  const renderDetails = (menuItem) => {
    return (
      <>
        <pre>{JSON.stringify(menuItem, null, 2)}</pre>
      </>
    );
  };

  const renderPath = (path) => {
    return (
      <>
        <pre>{<img src={path} alt='' />}</pre>
      </>
    );
  };

  const populateDetails = async () => {
    await axios({
      method: "get",
      url: "Values/ImagePath",
      params: {
        id: -1,
      },
    }).then((response) => {
      setPath(response.data);
    });

    await axios({
      method: "get",
      url: "Values/GetMenuItem",
      params: {
        id: -1,
      },
    }).then((response) => {
      setMenuItem(response.data);
      setLoading(false);
    });
  };

  useEffect(() => {
    populateDetails();
  }, [loading]);

  let content = loading ? <p>Loading...</p> : renderPath(path + "birm.png");

  return <>{content}</>;
};

export default Details;
