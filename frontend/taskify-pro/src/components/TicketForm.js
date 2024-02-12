import { useEffect, useState } from "react";
import Ticket from "./Ticket";

export default function TicketForm(props) {
  const ticketInitial = {
    id: 0,
    title: "",
    priority: "",
    description: "",
  };

  const [ticket, setTicket] = useState(ticketCurrent());

  useEffect(() => {
    if (props.ticketSelected.id !== 0) setTicket(props.ticketSelected);
  }, [props.ticketSelected]);

  const inputTextHandler = (e) => {
    const { name, value } = e.target;
    setTicket({ ...ticket, [name]: value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (props.ticketSelected.id !== 0) props.putTicket(ticket);
    else props.addTicket(ticket);

    setTicket(ticketInitial);
  };

  const handleCancel = (e) => {
    e.preventDefault();
    props.cancelTicket();
    setTicket(ticketInitial);
  };

  function ticketCurrent() {
    if (props.ticketSelected.id !== 0) return props.ticketSelected;
    else return ticketInitial;
  }

  return (
    <>      
      <form className="row g-3" onSubmit={handleSubmit}>
        <div className="col-md-6">
          <label className="form-label">Título</label>
          <input
            id="title"
            name="title"
            value={ticket.title}
            type="text"
            className="form-control"
            placeholder="Informe o Título"
            onChange={inputTextHandler}
          />
        </div>
        <div className="col-md-6">
          <label className="form-label">Prioridade</label>
          <select
            id="priority"
            name="priority"
            value={ticket.priority}
            className="form-select"
            onChange={inputTextHandler}
          >
            <option value={"NaoDefinido"}>Selecione...</option>
            <option value={"Baixa"}>Baixa</option>
            <option value={"Normal"}>Normal</option>
            <option value={"Alta"}>Alta</option>
          </select>
        </div>
        <div className="col-md-12">
          <label className="form-label">Descrição</label>
          <textarea
            id="description"
            name="description"
            value={ticket.description}
            type="text"
            className="form-control"
            placeholder="Informe a Descrição"
            onChange={inputTextHandler}
          />
          <hr />
        </div>
        <div className="col-12 mt-0">
          {ticket.id === 0 ? (
            <button className="btn btn-outline-success" type="submit">
              <i className="fas fa-plus me-2"></i>Novo
            </button>
          ) : (
            <>
              <button className="btn btn-outline-success me-2" type="submit">
                <i className="fas fa-floppy-disk me-2"></i>Salvar
              </button>
              <button
                className="btn btn-outline-warning"
                onClick={handleCancel}
              >
                <i className="fas fa-xmark me-2"></i>Cancelar
              </button>
            </>
          )}
        </div>
      </form>
    </>
  );
}
