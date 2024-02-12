import { useState, useEffect } from "react";
import "./App.css";
import { Button, Modal } from "react-bootstrap";
import TicketForm from "./components/TicketForm";
import TicketList from "./components/TicketList";
import api from "./api/ticket";

function App() {
  const [tickets, setTickets] = useState([]);
  const [ticket, setTicket] = useState({ id: 0 });
  const [showTicketModal, setShowTicketModal] = useState(false);
  const[smShowConfirmModal, setsmShowConfirmModal] = useState(false);

  const handleTicketModal = () => setShowTicketModal(!showTicketModal);

  const handleConfirmModal = (id) => {
    if(id !== 0 && id !== undefined){
      const ticketSelected = tickets.filter((tickets) => tickets.id === id);
      setTicket(ticketSelected[0]);      
    }else{
      setTicket({id:0});
    }
    setsmShowConfirmModal(!smShowConfirmModal);
  }

  const getAllTickets = async () => {
    const response = await api.get("ticket");
    return response.data;
  };

  useEffect(() => {
    const getTickets = async () => {
      const allTickets = await getAllTickets();

      if (allTickets) setTickets(allTickets);
    };

    getTickets();
  }, []);

  const newTicket = () => {
    setTicket({ id: 0 });
    handleTicketModal();
  }

  const addTicket = async (ticket) => {
    handleTicketModal();
    const response = await api.post("ticket", ticket);

    setTickets([...tickets, response.data]);    
  };

  const getTicket = (id) => {
    const ticketSelected = tickets.filter((tickets) => tickets.id === id);
    setTicket(ticketSelected[0]);
    handleTicketModal();
  }

  const cancelTicket = (ticket) => {
    setTicket({ id: 0 });
    handleTicketModal();
  }

  const putTicket = async (ticket) => {
    handleTicketModal();

    const response = await api.put(`ticket/${ticket.id}`, ticket);

    const { id } = response.data;

    setTickets(tickets.map((item) => (item.id === id ? response.data : item)));    
    setTicket({ id: 0 });    
  };

  const deleteTicket = async (id) => {
    if (await api.delete(`ticket/${id}`)) {
      const ticketsFiltered = tickets.filter((tickets) => tickets.id !== id);
      setTickets([...ticketsFiltered]);
    }
    handleConfirmModal(0);
  };

  return (
    <>
      <div className="d-flex justify-content-between align-items-end mt-2 pb-3 border-bottom border-1">
        <h1 className="m-0 p-0">Ticket {ticket.id !== 0 ? ticket.id : ""}</h1>
        <Button variant="outline-secondary" onClick={newTicket}>
          <i className="fas fa-plus"></i> Novo
        </Button>
      </div>

      <TicketList
        tickets={tickets}
        handleConfirmModal={handleConfirmModal}
        getTicket={getTicket}
      />

      <Modal show={showTicketModal} onHide={handleTicketModal}>
        <Modal.Header closeButton>
          <Modal.Title>Ticket {ticket.id !== 0 ? ticket.id : ""}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          <TicketForm
            tickets={tickets}
            ticketSelected={ticket}
            addTicket={addTicket}
            cancelTicket={cancelTicket}
            putTicket={putTicket}
          />
        </Modal.Body>
      </Modal>

      <Modal size="sm" show={smShowConfirmModal} onHide={handleConfirmModal}>
        <Modal.Header closeButton>
          <Modal.Title>Excluindo Ticket{' '} {ticket.id !== 0 ? ticket.id : ""}</Modal.Title>
        </Modal.Header>
        <Modal.Body>
          Tem certeza que deseja Excluir o Ticket {ticket.id}
        </Modal.Body>
        <Modal.Footer className="d-flex justify-content-between">
          <button className="btn btn-outline-success me-2" onClick={() => deleteTicket(ticket.id)}>
            <i className="fas fa-check me-2"></i>
            Sim
          </button>
          <button className="btn btn-danger me-2" onClick={() => handleConfirmModal(0)}>
          <i className="fas fa-times me-2"></i>
            Não
          </button>
        </Modal.Footer>
      </Modal>
    </>
  );
}

export default App;
