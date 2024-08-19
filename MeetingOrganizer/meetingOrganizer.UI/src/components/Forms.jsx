import React, { useContext, useEffect } from "react";
import "../assets/styles/forms.scss";
import DataContext from "../context/DataContext";

const Forms = () => {
  const {
    handleSubmit,
    setMeetingDescription,
    setStartTime,
    setEndTime,
    setParticipants,
    meetingDescription,
    startTime,
    endTime,
    participants,
    selectedMeeting,
    meetingDate,
    setMeetingDate,
  } = useContext(DataContext);

  const handleTimeChange = (e, setTime) => {
    const time = e.target.value;
    if (meetingDate) {
      const updatedTime = `${meetingDate}T${time}`;
      setTime(updatedTime);
    } else {
      setTime(time);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <h3>{selectedMeeting ? "Edit Meeting" : "Create New Meeting"}</h3>
      <label>Meeting Description</label>
      <input
        value={meetingDescription}
        onChange={(e) => setMeetingDescription(e.target.value)}
        type="text"
      />
      <label>Participants</label>
      <input
        value={participants}
        onChange={(e) => setParticipants(e.target.value)}
        type="text"
        placeholder="Participants"
      />
      <label>Meeting Date</label>
      <input
        value={meetingDate}
        onChange={(e) => setMeetingDate(e.target.value)}
        type="datetime-local"
      />
      <label>Meeting Start Time</label>
      <input
        value={startTime}
        onChange={(e) => setStartTime(e.target.value)}
        type="datetime-local"
      />

      <label>Meeting End Time</label>
      <input
        value={endTime}
        onChange={(e) => setEndTime(e.target.value)}
        type="datetime-local"
      />

      <input
        disabled={
          meetingDescription === "" ||
          meetingDate === "" ||
          startTime === "" ||
          endTime === "" ||
          participants === ""
        }
        type="submit"
        value={selectedMeeting ? "Edit" : "Save"}
      />
    </form>
  );
};

export default Forms;
