import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule, Routes } from '@angular/router';

import { ButtonModule } from 'primeng/button';
import { CardModule } from 'primeng/card';
import { PanelModule } from 'primeng/panel';
import { TabViewModule } from 'primeng/tabview';
import { ChartModule } from 'primeng/chart';
import { TableModule } from 'primeng/table';
import { InputGroupModule } from 'primeng/inputgroup';
import { InputGroupAddonModule } from 'primeng/inputgroupaddon';
import { DropdownModule } from 'primeng/dropdown';
import { SliderModule } from 'primeng/slider';
import { InputTextModule } from 'primeng/inputtext';
import { ProgressSpinnerModule } from 'primeng/progressspinner';
import { TagModule } from 'primeng/tag';
import { TabMenuModule } from 'primeng/tabmenu';
import { ToastModule } from 'primeng/toast';
import { InputNumberModule } from 'primeng/inputnumber';

import { AppComponent } from './app.component';
import { SelectionHeaderComponent } from './components/shared/selection-header/selection-header.component';
import { MutationHeaderComponent } from './components/shared/mutation-header/mutation-header.component';
import { CrossoverHeaderComponent } from './components/shared/crossover-header/crossover-header.component';
import { TerminationHeaderComponent } from './components/shared/termination-header/termination-header.component';
import { PopulationHeaderComponent } from './components/shared/population-header/population-header.component';
import { HeaderComponent } from './components/shared/header/header.component';
import { StressFormatPipe } from './shared/pipes/stress-format.pipe';
import { SpansFormatPipe } from './shared/pipes/spans-format.pipe';

import { CreatorComponent } from './components/creator/creator.component';
import { CalculationsComponent } from './components/calculations/calculations.component';
import { CalculationsDetailsComponent } from './components/calculations/calculations-details/calculations-details.component';
import { ChartComponent } from './components/calculations/calculations-details/chart/chart.component';
import { TableComponent } from './components/calculations/calculations-details/table/table.component';
import { StatsComponent } from './components/calculations/calculations-details/stats/stats.component';
import { DetailsComponent } from './components/calculations/calculations-details/details/details.component';
import { NumberFormatPipe } from './shared/pipes/number-format.pipe';
import { MessageService } from 'primeng/api';
import { StoreModule } from '@ngrx/store';
import { EffectsModule } from '@ngrx/effects';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { environment } from '../environments/environment';
import { appReducer } from './store/reducer';
import { AppEffects } from './store/effects';
import { TruncatePipe } from './shared/pipes/truncate.pipe';
import { DrawingComponent } from './components/calculations/calculations-details/drawing/drawing.component';
import { Drawing2dDirective } from './components/shared/drawing2d.directive';
import { MultiplyNumberPipe } from './shared/pipes/multiply-number.pipe';


const routes: Routes = [
  {
    path:
      'creator',
    component: CreatorComponent
  },
  {
    path: 'calculations',
    component: CalculationsComponent,
    children: [
      {
        path: ':calculationId',
        component: CalculationsDetailsComponent
      }
    ]
  },
  {
    path: '',
    redirectTo: '/creator',
    pathMatch: 'full'
  },
];

@NgModule({
  declarations: [
    AppComponent,
    ChartComponent,
    DetailsComponent,
    TableComponent,
    SelectionHeaderComponent,
    MutationHeaderComponent,
    CrossoverHeaderComponent,
    TerminationHeaderComponent,
    PopulationHeaderComponent,
    HeaderComponent,
    StatsComponent,
    StressFormatPipe,
    SpansFormatPipe,
    CreatorComponent,
    CalculationsComponent,
    CalculationsDetailsComponent,
    NumberFormatPipe,
    MultiplyNumberPipe,
    TruncatePipe,
    DrawingComponent,
    Drawing2dDirective
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule,
    StoreModule.forRoot({ app: appReducer }),
    EffectsModule.forRoot([AppEffects]),
    StoreDevtoolsModule.instrument({
      maxAge: 25,
      logOnly: !environment.production
    }),
    ButtonModule,
    CardModule,
    PanelModule,
    TabViewModule,
    ChartModule,
    TableModule,
    InputGroupModule,
    InputGroupAddonModule,
    DropdownModule,
    SliderModule,
    TabMenuModule,
    InputTextModule,
    ProgressSpinnerModule,
    TagModule,
    ToastModule,
    InputNumberModule
  ],
  providers: [MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
