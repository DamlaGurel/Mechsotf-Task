import React, {useContext} from "react";
import Card from "./Card";
import "../assets/styles/cardList.scss";
import DataContext from "../context/DataContext";

const CardList = () => {
  const {meetingList} = useContext(DataContext);
  return (
    <>
      <div className="card-list">
        {meetingList.map((meeting) => (
          <Card key={meeting.id} meeting={meeting} />
        ))}
      </div>
    </>
  );
};

export default CardList;
