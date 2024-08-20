import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, catchError, of, share, tap } from 'rxjs';
import { ProgressResponse } from './dto/progress-response';
import { environment } from '../../environments/environment';
import { uuid } from '../shared/uuid';
import { CalculationsResponse } from './dto/calculations-response';
import { Message, MessageService } from 'primeng/api';
import { CalculationsInput } from '../models/calculations-input';
import { v4 as uuidv4 } from 'uuid';


const api = `${environment.baseUrl}/api/calculations`
const errorMessage: Message = { severity: 'error', summary: 'Error', detail: 'Error occured', life: 1000 };
const calculationsStartedMessage: Message = { severity: 'success', summary: 'Success', detail: 'Calculations started', life: 5000 };

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private readonly http: HttpClient, private readonly messageService: MessageService) { }

  public getProgress(calculationId: uuid): Observable<ProgressResponse> {
    return this.http.get<ProgressResponse>(`${api}/${calculationId}`).pipe(
      share(),
      catchError(() => this.showError())
    );
  }

  public startCalculations(input: CalculationsInput): Observable<object> {
    const id = uuidv4();
    return this.http.put(`${api}/${id}`, input).pipe(
      tap(() => this.messageService.add(calculationsStartedMessage)),
      catchError(() => this.showError())
    );
  }

  public getCalculations(): Observable<CalculationsResponse> {
    return this.http.get<CalculationsResponse>(`${api}`).pipe(
      share(),
      catchError(() => this.showError())
    );
  }

  public removeCalculations(calculationId: uuid): Observable<object> {
    return this.http.delete(`${api}/${calculationId}`).pipe(
      catchError(() => this.showError())
    );
  }

  private showError() {
    this.messageService.clear();
    this.messageService.add(errorMessage);
    return of();
  }
}
