import { Component } from '@angular/core';
import { Injectable, Inject } from '@angular/core';
import { Http, Response} from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Router } from '@angular/router';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class StockService
{
    myAppUrl: string = "";
    constructor (private http : Http, @Inject('BASE_URL') base_url : string){  
        this.myAppUrl = base_url;
    }

    getStock(){
        return this.http.get(this.myAppUrl + 'api/InventoryAPI/Inventory')
        .map((response: Response)=>response.json())
        .catch(this.errorHandler)
    }

    addStock(item) {  
        return this.http.post(this.myAppUrl + 'api/InventoryAPI/AddInventory', item)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler)  
    } 

    updateStock(item) {  
        console.log(item);
        return this.http.put(this.myAppUrl + 'api/InventoryAPI/Edit', item)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    } 

    deleteStock(id) {  
        return this.http.delete(this.myAppUrl + "api/InventoryAPI/Delete/" + id)  
            .map((response: Response) => response.json())  
            .catch(this.errorHandler);  
    }
    
    errorHandler(error : Response){
        console.log(error);
        return Observable.throw(error);
    }
}