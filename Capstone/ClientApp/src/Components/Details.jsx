import React, { useState, useEffect } from 'react'
import axios from 'axios';

const Details = (props) => {
  const [menuItem, setMenuItem] = useState();
  const [loading, setLoading] = useState(true);

  const renderDetails = (menuItem) => {
    return (
      <>
        <pre>
          {JSON.stringify(menuItem, null, 2)}
        </pre>
      </>
    );
  }

  const populateDetails = async () => {
    const response = await axios({
      method: 'get',
      url: 'Values/GetMenuItem',
      params: {
        id : props.id
      }
    });
    setMenuItem(response.data);
    setLoading(false);
  }

  useEffect(() => {
    populateDetails();
  }, [loading]);

  let content = loading
    ? <p>Loading...</p>
    : renderDetails(menuItem);

  return (
    <>
      {content}
    </>
  );
}

export default Details;