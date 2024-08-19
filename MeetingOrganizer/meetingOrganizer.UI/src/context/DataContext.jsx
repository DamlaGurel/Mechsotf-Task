import axios from "axios";
import React, { createContext, useContext, useEffect, useState } from "react";

const DataContext = createContext();

export const DataProvider = ({ children }) => {
  const [meetingList, setMeetingList] = useState([]);
  const [meetingDescription, setMeetingDescription] = useState("");
  const [meetingDate, setMeetingDate] = useState("");
  const [startTime, setStartTime] = useState("");
  const [endTime, setEndTime] = useState("");
  const [participants, setParticipants] = useState("");
  const [selectedMeeting, setSelectedMeeting] = useState(null);

  const getMeetingList = async () => {
    try {
      const url = "https://localhost:7239/api/Meeting/GetMeetingList";
      const response = await axios.get(url);
      setMeetingList(response.data);
    } catch (error) {
      console.error("Error fetching meeting list:", error);
    }
  };

  const createMeeting = async (newMeeting) => {
    if (!selectedMeeting) {
      setMeetingList((prev) => [...prev, newMeeting]);
      try {
        const url = "https://localhost:7239/api/Meeting/CreateMeeting";
        const response = await axios.post(url, newMeeting);
        console.log(response);
      } catch (error) {
        console.error("Error adding new meeting:", error);
      }
    } else {
      try {
        const id = selectedMeeting.id;
        const url = `https://localhost:7239/api/Meeting/UpdateMeeting/${id}`;
        const response = await axios.put(url, newMeeting);
        setSelectedMeeting(null);

        setMeetingList((prev) =>
          prev.map((meeting) =>
            meeting.id === newMeeting.id ? response.data : meeting
          )
        );

        getMeetingList();
      } catch (error) {
        console.error("Error updating the meeting:", error);
      }
    }
  };

  const deleteMeeting = async (id) => {
    const approve = confirm("Are you sure want to delete this meeting?");
    if (approve) {
      try {
        const url = `https://localhost:7239/api/Meeting/DeleteSiteManager/${id}`;
        await axios.delete(url);
        setMeetingList((prev) => prev.filter((meeting) => meeting.id !== id));
      } catch (error) {
        console.error("Error deleting meeting:", error);
      }
    }
  };

  const updateMeeting = (id) => {
    const meetingToUpdate = meetingList.find((item) => item.id === id);
    setSelectedMeeting(meetingToUpdate);
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const newId =
      meetingList.length > 0
        ? (Number(meetingList[meetingList.length - 1].id) + 1).toString()
        : "1";
    createMeeting({
      id: newId,
      meetingDescription: meetingDescription,
      meetingDate: meetingDate,
      startTime: startTime,
      endTime: endTime,
      participants: participants,
    });
    setMeetingDescription("");
    setStartTime("");
    setEndTime("");
    setParticipants("");
    setMeetingDate("");
  };

  useEffect(() => {
    getMeetingList();
  }, []);

  useEffect(() => {
    if (selectedMeeting) {
      setMeetingDescription(selectedMeeting.meetingDescription);
      setMeetingDate(selectedMeeting.meetingDate);
      setStartTime(selectedMeeting.startTime);
      setEndTime(selectedMeeting.endTime);
      setParticipants(selectedMeeting.participants);
    }
  }, [selectedMeeting]);

  return (
    <DataContext.Provider
      value={{
        meetingList,
        handleSubmit,
        setMeetingDescription,
        setStartTime,
        setEndTime,
        meetingDescription,
        startTime,
        endTime,
        setParticipants,
        participants,
        deleteMeeting,
        selectedMeeting,
        updateMeeting,
        meetingDate,
        setMeetingDate,
      }}
    >
      {children}
    </DataContext.Provider>
  );
};

export default DataContext;
