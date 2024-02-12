import React from "react";

export default function Ticket(props) {
  function priorityLabel(param) {
    switch (param) {
      case 0:
      case "Naodefinido":
        return "Não definido";
      case 1:
      case "Baixa":
        return "Baixa";
      case 2:
      case "Normal":
        return "Normal";
      case 3:
      case "Alta":
        return "Alta";
      default:
        return "Não definido";
    }
  }

  function priorityStyle(param, icon) {
    switch (param) {
      case 0:
      case "Naodefinido":
        return "Não definido";
      case 1:
      case "Baixa":
        return icon ? "smile" : "success";
      case 2:
      case "Normal":
        return icon ? "meh" : "dark";
      case 3:
      case "Alta":
        return icon ? "frown" : "warning";
      default:
        return "Não definido";
    }
  }

  return (
    <div
      className={
        "card mb-2 shadow-sm border-" + priorityStyle(props.ticket.priority)
      }
    >
      <div className="card-body">
        <div className="d-flex justify-content-between">
          <h5 className="card-title">
            <span className="badge bg-secondary me-2">{props.ticket.id}</span>-{" "}
            {props.ticket.title}
          </h5>
          <h6>
            Prioridade:
            <span className={"ms-1 text-" + priorityStyle(props.ticket.priority)}>
              <i
                className={
                  "me-1 fa-regular fa-face-" +
                  priorityStyle(props.ticket.priority, true)
                }
              ></i>
              {priorityLabel(props.ticket.priority)}
            </span>
          </h6>
        </div>
        <p className="card-text">{props.ticket.description}</p>
        <div className="d-flex justify-content-end pt-2 m-0 border-top">
          <button
            className="btn btn-sm btn-outline-primary me-2"
            onClick={() => props.getTicket(props.ticket.id)}
          >
            <i className="fas fa-pen me-2"></i>
            Editar
          </button>
          <button
            className="btn btn-sm btn-outline-danger"
            onClick={() => props.handleConfirmModal(props.ticket.id)}
          >
            <i className="fas fa-trash me-2"></i>
            Deletar
          </button>
        </div>
      </div>
    </div>
  );
}
