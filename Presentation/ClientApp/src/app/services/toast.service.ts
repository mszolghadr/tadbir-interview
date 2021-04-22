import { Injectable, TemplateRef } from '@angular/core';
import { ToastMessage } from '../models/toast.model';

@Injectable({ providedIn: 'root' })
export class ToastService {
    toasts: ToastMessage[] = [];

    show(textOrTpl: string | TemplateRef<any>, options: any = {}) {
        this.toasts.push({ textOrTpl, ...options });
    }


    showStandard(textOrTpl: string | TemplateRef<any>, options: any = {}) {
        this.show(textOrTpl, { ...options, classname: 'bg-primary text-light' });
    }

    showSuccess(textOrTpl: string | TemplateRef<any>, options: any = {}) {
        this.show(textOrTpl, { ...options, classname: 'bg-success text-light' });
    }

    showDanger(textOrTpl: string | TemplateRef<any>, options: any = {}) {
        this.show(textOrTpl, { ...options, classname: 'bg-danger text-light' });
    }

    showWarning(textOrTpl: string | TemplateRef<any>, options: any = {}) {
        this.show(textOrTpl, { ...options, classname: 'bg-warning text-light' });
    }

    remove(toast) {
        this.toasts = this.toasts.filter(t => t !== toast);
    }
}