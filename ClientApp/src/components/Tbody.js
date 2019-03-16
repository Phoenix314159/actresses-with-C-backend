import React from 'react'

export default ({data, openPopUp}) => (
  <tbody>
  {data.map((row, i) => { //iterate over json object from server
            const { year, name, movie } = row  //pull off properties to display on every iteration
            console.log(year)
    return (
      <tr key={i} onClick={() => openPopUp(i)}>
        <td>{year}</td>
        <td>{name}</td>
        <td>{movie}</td>
      </tr>
    )
  })}
  </tbody>
)


