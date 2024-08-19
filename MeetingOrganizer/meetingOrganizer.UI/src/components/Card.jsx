import React, { useContext } from "react";
import "../assets/styles/card.scss";
import DataContext from "../context/DataContext";

const Card = ({ meeting }) => {
  const { deleteMeeting, updateMeeting } = useContext(DataContext);
  return (
    <div className="card">
      <h4>Description: {meeting.meetingDescription}</h4>
      <div className="card-body">
        <p>
          <b>Meeting Date: </b>
          {meeting.meetingDate}
        </p>
        <p>
          <b>Start Time: </b>
          {meeting.startTime}
        </p>
        <p>
          <b>End Time:</b> {meeting.endTime}
        </p>
        <p>
          <b>Participants:</b> {meeting.participants}
        </p>
      </div>

      <button onClick={() => deleteMeeting(meeting.id)} className="delete">
        Delete
      </button>
      <button onClick={() => updateMeeting(meeting.id)} className="update">
        Edit
      </button>
    </div>
  );
};

export default Card;
