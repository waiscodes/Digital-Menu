import React, { useState, useEffect } from 'react'
import { useParams } from 'react-router-dom';

const Details = () => {
  const { ID } = useParams();
  const [menuItem, setMenuItem] = useState();
  const [loading, setLoading] = useState(true);

  return (
    <>
    </>
  );
}

export default Details;