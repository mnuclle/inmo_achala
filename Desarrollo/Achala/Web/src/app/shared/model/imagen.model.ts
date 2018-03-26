export class Imagen {
  public id: number;
  public path: string;
  constructor(id?: number,
              path?: string) {
    this.id = id ? id : null;
    this.path = path;
    }
}
