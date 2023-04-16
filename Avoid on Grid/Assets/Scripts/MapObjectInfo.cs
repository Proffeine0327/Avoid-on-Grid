using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class MapObjectInfo
{
    [Serializable]
    public class PositionKeyFrame
    {
        public Vector3 position;
        public EaseType easeType;
        public float time;
    }

    [Serializable]
    public class RotationKeyFrame
    {
        public Vector3 rotate;
        public EaseType easeType;
        public float time;
    }

    [Serializable]
    public class ScaleKeyFrame
    {
        public Vector3 scale;
        public EaseType easeType;
        public float time;
    }

    public int id;
    public List<PositionKeyFrame> positionKeyFrames = new List<PositionKeyFrame>();
    public List<RotationKeyFrame> rotationKeyFrames = new List<RotationKeyFrame>();
    public List<ScaleKeyFrame> scaleKeyFrames = new List<ScaleKeyFrame>();
}