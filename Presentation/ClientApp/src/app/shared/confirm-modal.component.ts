import { Component, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'app-confirm-modal',
    template: `
    <div class="modal-header">
      <h4 class="modal-title">{{header}}</h4>
      <button type="button" class="close" aria-label="Close" (click)="activeModal.dismiss('NO')">
        <span aria-hidden="true">&times;</span>
      </button>
    </div>
    <div class="modal-body">
      <p>{{message}}!</p>
    </div>
    <div class="modal-footer">
      <button type="button" class="btn btn-danger" (click)="activeModal.close('YES')">تایید</button>
      <button type="button" ngbAutofocus class="btn btn-outline-dark" (click)="activeModal.dismiss('NO')">بازگشت</button>
    </div>
  `,
    styles: ['.modal-header .close {margin: -1rem}']
})
export class ConfirmModalComponent {
    @Input() message;
    @Input() header;

    constructor(public activeModal: NgbActiveModal) { }
}
