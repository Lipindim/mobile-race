using System;
using System.Collections.Generic;
using Tools;
using UnityEngine;


namespace Controllers
{

    public abstract class BaseController : IDisposable
    {

        #region Fields

        private List<BaseController> _baseControllers;
        private List<GameObject> _gameObjects;

        private bool _isDisposed;

        #endregion


        #region Methods

        protected void AddController(BaseController baseController)
        {
            if (_baseControllers == null)
                _baseControllers = new List<BaseController>();
            _baseControllers.Add(baseController);
        }

        protected void AddGameObjects(GameObject gameObject)
        {
            if (_gameObjects == null)
                _gameObjects = new List<GameObject>();
            _gameObjects.Add(gameObject);
        }

        protected virtual void OnDispose()
        {

        }

        protected T LoadView<T>(string viewPath, Transform parrent = null)
        {
            GameObject prefab = ResourceLoader.LoadPrefab(viewPath);
            GameObject viewObject;
            if (parrent == null)
                viewObject = GameObject.Instantiate(prefab);
            else
                viewObject = GameObject.Instantiate(prefab, parrent, false);

            AddGameObjects(viewObject);
            return viewObject.GetComponent<T>();
        }

        #endregion


        #region IDisposable

        public void Dispose()
        {
            if (!_isDisposed)
            {
                _isDisposed = true;
                if (_baseControllers != null)
                {
                    foreach (BaseController baseController in _baseControllers)
                    {
                        baseController?.Dispose();
                    }
                    _baseControllers.Clear();
                }

                if (_gameObjects != null)
                {
                    foreach (GameObject cachedGameObject in _gameObjects)
                    {
                        GameObject.Destroy(cachedGameObject);
                    }
                    _gameObjects.Clear();
                }

                OnDispose();
            }
        }

        #endregion

    }
}