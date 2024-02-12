import React from 'react'
import Ticket from './Ticket';

export default function TicketList(props) {
  return (
    <div className="mt-3">          
            {props.tickets.map(ticket => (
              <Ticket 
                key={ticket.id} 
                handleConfirmModal={props.handleConfirmModal}
                getTicket={props.getTicket}
                ticket={ticket}
                />
            ))}
      </div>
  )
}
